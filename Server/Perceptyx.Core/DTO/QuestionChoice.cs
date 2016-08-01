﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.DTO
{
    public class QuestionChoice
    {
        public QuestionChoice()
        {

        }

        public QuestionChoice(Model.QuestionChoice model)
        {
            this.Id = model.Id;
            this.QuestionId = model.QuestionId;
            this.Ordinal = model.Ordinal;
            this.Value = model.Value;
            this.CreatedBy = model.CreatedBy;
            this.CreatedDate = model.CreatedDate;
            this.UpdatedDate = model.UpdatedDate;
            this.UpdatedOn = model.UpdatedOn;
        }

        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int Ordinal { get; set; }

        public string Value { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedOn { get; set; }
    }
}
