using AutoMapper;

using Domain.Business.Vehicles;

using Vehicles.Service.ViewModels;

namespace Vehicles.Service.Profiles {
    public class VehicleMapperProfile : Profile {
        public VehicleMapperProfile() {
            CreateMap<VehicleViewModel, VehicleEntity>()
                .ConstructUsing(x => new VehicleEntity(string.IsNullOrEmpty(x.Id) ? VehicleId.New : VehicleId.With(x.Id)));

        }
    }
}