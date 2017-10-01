using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektRestauracja.Domain.Entities;
using ProjektRestauracja.WebUI.Models;
using ProjektRestauracja.Domain.Abstract;


namespace ProjektRestauracja.WebUI.Controllers
{
    
    public class OrderController : Controller
    {

        private IGenericRepository<Order> orderRepository;
        private IGenericRepository<Product> productRepository;
        private IGenericRepository<OrderPosition> positionRepository;
        private IGenericRepository<Client> clientRepository;

        public OrderController (IGenericRepository<Order> oRepo,IGenericRepository<Product> pRepo, IGenericRepository<OrderPosition> opRepo, IGenericRepository<Client> cRepo)
        {
            this.orderRepository = oRepo;
            this.productRepository = pRepo;
            this.positionRepository = opRepo;
            this.clientRepository = cRepo;
        }

        

        // GET: Order
        [Authorize]
        public ViewResult List()
        {
            
            
            IEnumerable<OrderViewModel> orders = from o in orderRepository.Entities
                                                    join p in positionRepository.Entities on o.OrderNr equals p.OrderNr
                                                    into orderPositions
                                                    let id = from c in clientRepository.Entities
                                                             where c.Email == ControllerContext.HttpContext.User.Identity.Name
                                                             select c.ID
                                                 where id.FirstOrDefault() == o.ClientID
                                                 select new OrderViewModel { _Order = o, Positions = orderPositions };

            OrderListViewModel viewModel = new OrderListViewModel() {

               
                Orders = orders,
                Products = productRepository.Entities

            };

            return View(viewModel);
        }

        public ViewResult AddOrder(OrderMaker model, int ProductID=0) {

            if (model.Menu == null)
              model.Menu = productRepository.Entities;

            model.IdToChange = ProductID;


            return View(model);
            
        }

        
        public ActionResult SaveOrder(OrderMaker model) {

            if (model.Positions.Any()) {

                Order newOrder = new Order() {

                    ClientID = clientRepository.Entities.Where(x => x.Email == ControllerContext.HttpContext.User.Identity.Name).FirstOrDefault().ID,
                    WaiterID = 1,
                    OrderValue = model.CalculateTotalCost(),
                    OrderDateTime = DateTime.Now

                };

                orderRepository.SaveEntity(newOrder);


                int newid;
                newid = orderRepository.Entities.LastOrDefault().OrderNr;


                foreach (var x in model.Positions) {
                    x.OrderNr = newid;
                    positionRepository.SaveEntity(x);
                }

                model.PositionNr = 1;
                model.Positions.Clear();
                return RedirectToAction("List");
            }

            else {
                
                ModelState.AddModelError("", "Zamówienie nie może być puste");
                return View("AddOrder",model);
            }
            
        }

        /*
        public RedirectToRouteResult AddPosition(OrderMaker model, int ProductID) {

            model.AddPosition(ProductID);

            return RedirectToAction("AddOrder");
        }

        public RedirectToRouteResult RemovePosition(OrderMaker model, int ProductID) {

            model.RemovePosition(ProductID);
            return RedirectToAction("AddOrder");
        }*/

        public PartialViewResult UpdatePositionList(OrderMaker model, int ProductID) {



            if (ProductID < 0)
                model.RemovePosition(-ProductID);
            else if (ProductID > 0)
                model.AddPosition(ProductID);

            return PartialView(model);
        }
    }
}