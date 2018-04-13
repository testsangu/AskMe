using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
    interface ICategoryBAL
    {
        List<QuestionsCategory> GetAllCategory();

        void AddQuestionCategory(QuestionsCategory category);

        QuestionsCategory GetCategoryById(int id);

        void DeleteQuestoinsCategory(QuestionsCategory category);
    }
}
