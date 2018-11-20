using Jwell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jwell.Application.Services.Dtos
{
    public class ServiceInfoDto
    {
        public string ServiceNumber { get; set; }

        public string ServiceName { get; set; }

        public string ServiceSign { get; set; }

        public string OwnerId { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }

    public class TeamInfoDto
    {     
        public string LeaderId { get; set; }

        public string LeaderName { get; set; }

        public string TeamCode { get; set; }    

        public List<ServiceInfoDto> ServiceInfoes { get; set; }

        public TeamInfoDto()
        {
            ServiceInfoes = new List<ServiceInfoDto>();
        }
    }

    public static class TeamInfoDtoExt
    {
        public static IEnumerable<TeamInfoDto> ToDtos(this IQueryable<Service> query)
        {
            var services = query.ToList();
            var teamInfoDtos = new List<TeamInfoDto>();

            foreach(var service in services)
            {
                var serviceInfoDto = new ServiceInfoDto
                {
                    ServiceNumber = service.ServiceNumber,
                    ServiceName = service.Name,
                    ServiceSign = service.ServiceSign,
                    OwnerId = service.Owner,
                    CreatedBy = service.CreatedBy,
                    ModifiedBy = service.ModifiedBy,
                    CreatedTime = service.CreatedTime,
                    ModifiedTime = service.ModifiedTime
                };

                if (!teamInfoDtos.Exists(t=>t.TeamCode == service.TeamCode))
                {
                    var teamInfoDto = new TeamInfoDto
                    {
                        LeaderId = service.LeaderId,
                        TeamCode = service.TeamCode,
                    };

                    teamInfoDto.ServiceInfoes.Add(serviceInfoDto);
                    teamInfoDtos.Add(teamInfoDto);
                }
                else
                {
                    teamInfoDtos.Find(t => t.TeamCode == service.TeamCode).ServiceInfoes.Add(serviceInfoDto);                   
                }
            }
            return teamInfoDtos;
        }
    }
}
