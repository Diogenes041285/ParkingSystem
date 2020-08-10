using AutoMapper;
using ParkingSystem.Api.ViewModels;
using ParkingSystem.Model;

namespace ParkingSystem.Api.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<Carro, CarroViewModel>().ReverseMap();
			CreateMap<Manobra, ManobraViewModel>().ReverseMap();
			CreateMap<Manobrista, ManobristaViewModel>().ReverseMap();
		}
	}
}
