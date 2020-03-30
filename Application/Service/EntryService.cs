using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Interfaces;
using Domain;
using Application.Mapper;
using Infra.Data;

namespace Application.Service
{
    public class EntryService : IEntryService
    {

      
      
        private UnitOfWork _unitOfWork;
    
        public EntryService( UnitOfWork unitOfWork )
        {
            this._unitOfWork = unitOfWork;

        }

        public void CreateNewEntry(EntryViewModel entry)
        {



            _unitOfWork.Entryrepository.CreateNewEntry(EntryMapper.MapToModel(entry));
            _unitOfWork.Save();
            //_er.CreateNewEntry(EntryMapper.MapToModel(entry));

        }

        public void DeleteEntry(int id)
        {

            // _er.DeleteEntry(id);
            _unitOfWork.Entryrepository.DeleteEntry(id);
            _unitOfWork.Save();
        }

        public List<EntryViewModel> GetEntries()
        {

            //var behindicator = repository.Get(a => a.IsActive && a.behObjective.IsActive);
            //return behindicator.Select(BehIndicatorMapper.Map).ToList();

            return _unitOfWork.Entryrepository.GetEntries().Select(EntryMapper.Map).ToList();
            //return _er.GetEntries().Select(EntryMapper.Map).ToList();
        }

        public EntryViewModel GetEntry(int id)
        {
            //    var behindicator = repository.Get(x => x.BehIndicatorId == id).FirstOrDefault();
            //    return BehIndicatorMapper.Map(behindicator);

            //var entry = _er.Get(x => x.EntryId == id,null,"").FirstOrDefault();
            var entry=_unitOfWork.Entryrepository.Get(x => x.EntryId == id, null, "").FirstOrDefault();
            return EntryMapper.Map(entry);
         
                
        }

      

        public void UpdateEntry( EntryViewModel dto)
        {
            var oldEntry = _unitOfWork.Entryrepository.GetEntry(dto.entryid);
            if (oldEntry != null)
            {
                oldEntry.EntryId = dto.entryid;
                oldEntry.IsExpense = dto.isexpense;
                oldEntry.value = dto.value;

                _unitOfWork.Entryrepository.UpdateEntry(oldEntry); ;
                _unitOfWork.Save();
            }
        }



        //public void Create(CreateBehIndicatorDTO dto)
        //{

        //    if (DoesBehIndicatorTitleExist(dto))
        //        throw new DuplicateRecordException();
        //    dto.IsActive = true;
        //    repository.Create(BehIndicatorMapper.MapToModel(dto));
        //}

        //public void Edit(ModifyBehIndicatorDTO dto)
        //{
        //    var behindicator = repository.GetById(dto.BehIndicatorId);
        //    behindicator.BehIndicatorId = dto.BehIndicatorId;
        //    behindicator.BehObjectiveId = dto.BehObjectiveId;
        //    behindicator.BehIndicatorDsc = dto.BehIndicatorDsc;
        //    behindicator.Instances = dto.Instances;
        //    behindicator.IsActive = dto.IsActive;
        //    repository.Edit(behindicator);
        //}
        //public void Delete(int id)
        //{

        //    var behIndicator = repository.GetById(id);
        //    var existingPerfApprisalDtl = repository.Get(a => a.BehIndicatorId == id);
        //    if (!existingPerfApprisalDtl.Any())
        //    {
        //        repository.Delete(behIndicator);
        //    }
        //    else
        //    {
        //        behIndicator.IsActive = false;
        //        repository.Edit(behIndicator);
        //    }

        //}

    }
}
