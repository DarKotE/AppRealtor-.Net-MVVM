using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Esoft.ClassFolder.ModelsFolder;


namespace Esoft.ClassFolder
{
    public class Validator
    {
        public DataController DataController { get; set; }
        public string Validate(Complex complex)
        {
            if (complex == null)
            {
                return "Ошибка передачи данных";
            }
            if (String.IsNullOrEmpty(complex.NameHousingComplex))
            {
                return "Введите имя жилищного комплекса";
            }
            if (complex.AddedValue < 0)
            {
                return "Добавочная стоимость должна быть неотрицательной";
            }
            if (String.IsNullOrEmpty(complex.StatusConstructionHousingComplex))
            {
                return "Укажите статус ЖК";
            }
            if (complex.BuildingCost < 0)
            {
                return "Затраты на строительство должны быть неотрицательными";
            }
            if (String.IsNullOrEmpty(complex.City))
            {
                return "Укажите город";
            }
            if (complex.AddedValue < 0)
            {
                return "Добавочная стоимость должна быть неотрицательной";
            }
            if (String.IsNullOrEmpty(complex.StatusConstructionHousingComplex))
            {
                return "Укажите статус ЖК";
            }
            if (complex.BuildingCost < 0)
            {
                return "Затраты на строительство должны быть неотрицательными";
            }
            if (String.IsNullOrEmpty(complex.City))
            {
                return "Укажите город";
            }
            if(complex.StatusConstructionHousingComplex.Equals(Const.StatusConstructionValue.Plan))
            {
                DataController = new DataController();
                if(!DataController.CanPlan(complex))
                    return "Невозможно установить выбранный статус т.к. в данном комплексе есть проданные квартиры";
            }
            if (!complex.StatusConstructionHousingComplex.Equals(Const.StatusConstructionValue.Plan))
            {
                return String.Empty; //passed
            }
            DataController = new DataController();
            if (!DataController.CanPlan(complex))
            {
                return "Невозможно установить выбранный статус т.к. в данном комплексе есть проданные квартиры";
            }
                
            return String.Empty; //passed
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
