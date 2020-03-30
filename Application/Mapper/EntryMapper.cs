using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Application.ViewModels;

namespace Application.Mapper

{
    public class EntryMapper
    {
        public static EntryViewModel Map(Entry map)
        {
            var entrydto = new EntryViewModel()
            {
                entryid = map.EntryId,
                desc = map.Desc,
                isexpense = map.IsExpense,
                value = map.value,
               

            };


          

            return entrydto;

        }


        public static Entry MapToModel(EntryViewModel map)
        {
        return new Entry()
        {
            EntryId = map.entryid,
            IsExpense = map.isexpense,
            Desc = map.desc,
                value = map.value,

            };
        }

        //AutoMapper.Mapper.CreateMap<Entry,EntryViewModel>();
        //uAnotherObj = AutoMapper.Mapper.Map<EntryViewModel>(uObj);
    }
}


//using System.Collections.Generic;
//using System.Linq;
//using AMAR.Application.Contract.PerformanceManagment.DTO.Create;
//using AMAR.Application.Contract.PerformanceManagment.DTO.List;
//using AMAR.Domain.PerformanceManagment.Model;

//namespace AMAR.Application.PerformanceManagment.Mapper
//{
//    public class BehIndicatorMapper
//    {
//        public static BehIndicatorDTO Map(BehIndicator map)
//        {
//            var behIndicatorDto = new BehIndicatorDTO()
//            {
//                BehIndicatorId = map.BehIndicatorId,
//                BehObjectiveId = map.BehObjectiveId,
//                BehIndicatorDsc = map.BehIndicatorDsc,
//                IsActive = map.IsActive,
//                Description = map.Description,

//            };
//            behIndicatorDto.Instances = new List<string>();
//            if (!string.IsNullOrEmpty(map.Instances))
//            {
//                var instances = map.Instances.Split('-').ToList();
//                behIndicatorDto.Instances.AddRange(instances);
//            }

//            return behIndicatorDto;
//        }


//        public static BehIndicator MapToModel(CreateBehIndicatorDTO map)
//        {
//            return new BehIndicator()
//            {
//                BehIndicatorId = map.BehIndicatorId,
//                BehObjectiveId = map.BehObjectiveId,
//                BehIndicatorDsc = map.BehIndicatorDsc,
//                Description = map.Description,
//                IsActive = map.IsActive,
//                Instances = map.Instances,

//            };
//        }
//    }
//}
