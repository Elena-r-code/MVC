using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.FeedbackViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IFeedbackService
    {
        FeedbackDetailsViewModel GetFeedbackDetails(int id);
        List<FeedbackListViewModel> GetAllFeedbacks();
        Feedback CreateFeedback(FeedbackViewModel feedbackViewModel);
        Feedback EditFeedback(FeedbackViewModel feedbackViewModel);
        void DeleteFeedback(int id);
    }
}
