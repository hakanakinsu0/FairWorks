using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class FairDelayRepository:BaseRepository<FairDelay>
    {
        public List<string> GetFormattedDelayHistory(int fairId)
        {
            return Where(fd => fd.FairId == fairId).Select(delay =>
                $"Gecikme Süresi: {delay.DelayDuration} gün - Sebep: {delay.DelayReason} - Yeni Başlangıç: {delay.NewStartDate:dd/MM/yyyy} - Yeni Bitiş: {delay.NewEndDate:dd/MM/yyyy}")
            .ToList();
        }

       


    }
}
