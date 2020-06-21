using System;
using System.Collections.Generic;
using System.Linq;

namespace Esoft.ClassFolder
{
    public class Validator
    {
        public DataController DataController { get; }
        public string Validate(Complex complex)
        {
            var err = String.Empty;
            if (String.IsNullOrEmpty(complex.NameHousingComplex))
            {
                return err="Введите имя жилищного комплекса";
            }
            else if (complex.AddedValue < 0)
            {
                return err = "Добавочная стоимость должна быть неотрицательной";
            }
            else if (String.IsNullOrEmpty(complex.StatusConstructionHousingComplex))
            {
                return err = "Укажите статус ЖК";
            }
            else if (complex.BuildingCost < 0)
            {
                return err = "Затраты на строительство должны быть неотрицательными";
            }
            else if (String.IsNullOrEmpty(complex.City))
            {
                return err = "Укажите город";
            }
            else if (complex.StatusConstructionHousingComplex.Equals("1"))
            {
                
                    //todo доделать условие
                if (false)
                {
                    return err = "В редактируемом жилищном комплексе есть квартирысо статусом “продана”.";
                }
                
            }
            return err;
        }

        public string Validate(House house)
        {
            var err = String.Empty;
            if (String.IsNullOrEmpty(house.Street))
            {
                return err = "Введите улицу";
            }
            else if (String.IsNullOrEmpty(house.NumberHouse))
            {
                return err = "Введите номер дома";
            }
            else if (house.IdComplex==0)
            {
                return err = "Выберите ЖК";
            }
            else if (house.CostHouseConstruction < 0)
            {
                return err = "Затраты на строительство должны быть неотрицательными";
            }
            else if (house.AdditionalCostHouseConstruction < 0)
            {
                return err = "Rоэффициент добавочной стоимости должен быть неотрицательным";
            }
            return err;
        }



    }
}
