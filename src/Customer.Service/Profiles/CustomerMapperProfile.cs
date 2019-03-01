using AutoMapper;

using Customer.Service.ViewModels;

using VehicleTracker.Business.VehicleDomain;

namespace Customer.Service.Profiles {
    public class CustomerMapperProfile : Profile {
        public CustomerMapperProfile() {
            CreateMap<CustomerViewModel, VehicleEntity>()
                .ConstructUsing(x => new VehicleEntity(string.IsNullOrEmpty(x.Id) ? VehicleId.New : VehicleId.With(x.Id)));

        }
    }
}