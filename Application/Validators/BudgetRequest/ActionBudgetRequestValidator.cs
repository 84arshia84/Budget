using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.ActionBudgetRequest;
using Application.Dto.BudgetRequest;
using Microsoft.VisualBasic;

namespace Application.Validators.BudgetRequest
{
    public class ActionBudgetRequestValidator
    {
        public void Validate(List<BudgetAmountPeriodDto> dtos)
        {
           
            for (int i = 0; i < dtos.Count; i++)
            {

                if (dtos[i] == null) throw new ArgumentNullException(nameof(dtos));

                if (!int.TryParse(dtos[i].EstimationRange, out int nummber))
                    throw new ArgumentException("عدد وارد شده صحیح نیست ");
                if (dtos[i].EstimationRange.Length != 6)
                    throw new ArgumentException("تاریخ وارد شده باید شامل ماه و سال باشد و 6 کاراکتر باشد  به طور مثال 140401");
                var yearPart = dtos[i].EstimationRange.Substring(0, 4);
                var monthPart = dtos[i].EstimationRange.Substring(4, 2);

                if (!int.TryParse(yearPart, out int year) || year < 1300 || year > 1500)
                    throw new ArgumentException("سال وارد شده باید بین 1300 تا 1500 باشد ");
                if (!int.TryParse(monthPart, out int month) || month < 1 || month > 12)
                    throw new ArgumentException("ماه وارد شده باید بین  01 تا 12 باشد ");

                if (!int.TryParse(dtos[i].PlannedAmount, out int planned))
                    throw new ArgumentException("ورودی باید عدد باشد ");

                if (!int.TryParse(dtos[i].RequestedAmount, out int Requested))
                    throw new ArgumentException("ورودی باید عدد باشد ");

            }

        }

        public void Validator(AddBudgetRequestDto dto)
        {


            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }

            if (dto.year < 1300 || dto.year > 1500)
                throw new ArgumentException("سال باید بین 1300 تا 1500 باشد ");
        }
        public void Validator(UpdateBudgetRequestDto dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }

            if (dto.year < 1300 || dto.year > 1500)
                throw new ArgumentException("سال باید بین 1300 تا 1500 باشد ");

        }
        public void Validator(List<ActionBudgetRequestDto> dtos)
        {

            foreach (ActionBudgetRequestDto dto in dtos)
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }
            }


        }
    }
}
 //dtos = [{name:"abbas"},{name:"ali"}]
            // dtos[0]={name:"abbas"}
            //dtos[0].name="abbas"