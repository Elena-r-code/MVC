using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.Shared.CustomExceptions;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        
       
        private IPizzaRepository _pizzaRepository;
        public OrderService(IRepository<Order> orderRepository,  IPizzaRepository pizzaRepository)
        {
           
            _orderRepository = orderRepository;
           
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel)
        {
            Pizza pizzaDb = _pizzaRepository.GetById(pizzaOrderViewModel.PizzaId);
            if(pizzaDb == null)
            {
               
                throw new Exception($"Pizza with id {pizzaOrderViewModel.PizzaId} was not found");
            }
            Order orderDb = _orderRepository.GetById(pizzaOrderViewModel.OrderId);
            if (orderDb == null)
            {
               
                throw new Exception($"Order with id {pizzaOrderViewModel.OrderId} was not found");
            }

            orderDb.PizzaOrders.Add(new PizzaOrder
            {
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                PizzaSize = pizzaOrderViewModel.PizzaSize
            });
            _orderRepository.Update(orderDb);
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
           
            Order order = orderViewModel.ToOrder();
            

            int newOrderId = _orderRepository.Insert(order);
            if(newOrderId <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }

        public void DeleteOrder(int id)
        {
            
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
            _orderRepository.DeleteById(id);
        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {orderViewModel.Id} was not found!");
            }
            
           

            Order editedOrder = orderViewModel.ToOrder();
            
            editedOrder.Id = orderViewModel.Id;
         
            editedOrder.PizzaOrders = orderDb.PizzaOrders;
     
            _orderRepository.Update(editedOrder);
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            
            List<Order> dbOrders = _orderRepository.GetAll();

            
            return dbOrders.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.ToOrderDetailsViewModel();
        }

        public OrderViewModel GetOrderForEditing(int id)
        {
            
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
           
            return orderDb.ToOrderViewModel();
        }
    }
}
