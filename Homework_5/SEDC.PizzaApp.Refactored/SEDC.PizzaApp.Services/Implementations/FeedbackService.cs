using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.FeedbackViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private IRepository<Feedback> _feedbackRepository;
        public FeedbackService(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public Feedback CreateFeedback(FeedbackViewModel feedbackViewModel)
        {
            List<Feedback> feedbacks = _feedbackRepository.GetAll().Where(x => x.Email == (feedbackViewModel.ToFeedback()).Email).ToList();
            if (feedbacks.Count == 3)
            {
                throw new Exception("Only 3 feedbacks allowed per e-mail");
            }
            Feedback feedback = feedbackViewModel.ToFeedback();
            int newFeedbackId = _feedbackRepository.Insert(feedback);
            return feedback;
           
        }

        public void DeleteFeedback(int id)
        {
            Feedback feedbackDb = _feedbackRepository.GetById(id);
            _feedbackRepository.DeleteById(id);
        }

        public Feedback EditFeedback(FeedbackViewModel feedbackViewModel)
        {
            Feedback feedbackDb = _feedbackRepository.GetById(feedbackViewModel.Id);
     
            Feedback FeedbackAfterEdit = feedbackViewModel.ToFeedback();
            FeedbackAfterEdit.Id = feedbackViewModel.Id;
            FeedbackAfterEdit.FeedbackNew = feedbackDb;
            _feedbackRepository.Update(FeedbackAfterEdit);
            return FeedbackAfterEdit;
        }

        public List<FeedbackListViewModel> GetAllFeedbacks()
        {
            List<Feedback> feedbacksDb = _feedbackRepository.GetAll();
            return feedbacksDb.Select(x => FeedbackMapper.FeedbackToFeedbackListViewModel(x)).ToList();
        }

        public FeedbackDetailsViewModel GetFeedbackDetails(int id)
        {
            Feedback feedbackDb = _feedbackRepository.GetById(id);
  
            return feedbackDb.FeedbackDetailsViewModel();
        }
    }
}
