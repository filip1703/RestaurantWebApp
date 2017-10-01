using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektRestauracja.Domain.Abstract;
using ProjektRestauracja.WebUI.Models;
using ProjektRestauracja.Domain.Entities;

namespace ProjektRestauracja.WebUI.Controllers
{
    [Authorize]
    public class BookingController : Controller {

        private IGenericRepository<Booking> bookingRepository;
        private IGenericRepository<Table> tableRepository;
        private IGenericRepository<Client> clientRepository;

        public BookingController(IGenericRepository<Booking> bRepo, IGenericRepository<Table> tRepo, IGenericRepository<Client> cRepo) {
            bookingRepository = bRepo;
            tableRepository = tRepo;
            clientRepository = cRepo;
        }
        // GET: Booking
        public ViewResult List() {

            int currentClientID = clientRepository.Entities.Where(x => x.Email == HttpContext.User.Identity.Name).FirstOrDefault().ID;

            BookingListViewModel viewModel = new BookingListViewModel() {
                Bookings = this.bookingRepository.Entities.Where(x=>x.ClientID == currentClientID),
                Tables = this.tableRepository.Entities
            };
        
            return View(viewModel);
        }

        
        public ViewResult AddBooking() {

            return View(new Visit());
        }

        [HttpPost]
        public ActionResult AddBooking(Visit visit) {

            if (ModelState.IsValid) {

                if (visit.VisitDateTime < DateTime.Now) {
                    ModelState.AddModelError("", "Data rezerwacji nie może być z przeszłości");
                    return View("AddBooking", visit);
                }
                else {

                    List<int> matchingTablesNr = new List<int>();

                    foreach (var t in tableRepository.Entities) {

                        if (t.TableLocation == visit.VisitTable.TableLocation && t.Size == visit.VisitTable.Size) {

                            matchingTablesNr.Add(t.TableNr);
                        }
                    }

                    foreach (var b in bookingRepository.Entities) {

                        if (b.VisitDateTime > DateTime.Now && (b.VisitDateTime - visit.VisitDateTime).Duration().Ticks <= TimeSpan.TicksPerHour) {

                            if (matchingTablesNr.Contains(b.TableNr)) {
                                matchingTablesNr.Remove(b.TableNr);
                            }
                        }
                    }

                    if (matchingTablesNr.Any()) {

                        Booking newB = new Booking();
                        newB.BookingNr = 0;
                        newB.BookingDate = DateTime.Now;
                        newB.ClientID = clientRepository.Entities.Where(x => x.Email == ControllerContext.HttpContext.User.Identity.Name).FirstOrDefault().ID;
                        newB.Realization = false;
                        newB.TableNr = matchingTablesNr.FirstOrDefault();
                        newB.VisitDateTime = visit.VisitDateTime;

                        bookingRepository.SaveEntity(newB);

                        return RedirectToAction("List");
                    }

                    else {
                        ModelState.AddModelError("", "Brak wolnych stolików tego typu dla podanej godziny");
                        return View("AddBooking", visit);
                    }
                }
                
            }
            else {
                return View("AddBooking", visit);
            }
        }
    }
}