﻿using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.FeedbackViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public IActionResult Index()
        {
            List<FeedbackListViewModel> feedbackListViewModels = _feedbackService.GetAllFeedbacks();
            return View(feedbackListViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception("Bad Request");
            }
            try
            {
                FeedbackDetailsViewModel feedbackDetailsViewModel = _feedbackService.GetFeedbackDetails(id.Value);
                return View(feedbackDetailsViewModel);
            }
            catch
            {
                return View("ExceptionPage");
            }
        }
        public IActionResult Create()
        {
            FeedbackViewModel feedbackViewModel = new FeedbackViewModel();
            return View(feedbackViewModel);
        }

        [HttpPost]
        public IActionResult Create(FeedbackViewModel feedbackViewModel)
        {
            try
            {
                _feedbackService.CreateFeedback(feedbackViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Exception page");
            }
        }

        
        [HttpPost]
        public IActionResult Edit(FeedbackViewModel feedbackViewModel)
        {
            try
            {
                _feedbackService.EditFeedback(feedbackViewModel);
                return RedirectToAction("Index");
            }
           
            catch (Exception)
            {
                return View("ExceptionPage");
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                FeedbackDetailsViewModel feedbackDetailsViewModel = _feedbackService.GetFeedbackDetails(id.Value);
                return View(feedbackDetailsViewModel);
            }
            catch
            {
                return View("ExceptionPage");
            }
        }
        [HttpPost]
        public IActionResult Delete(FeedbackDetailsViewModel feedbackDetailsViewModel)
        {
            try
            {
                _feedbackService.DeleteFeedback(feedbackDetailsViewModel.Id);
                return RedirectToAction("Index");
            }
           
            catch (Exception)
            {
                return View("ExceptionPage");
            }
        }
    }
}
