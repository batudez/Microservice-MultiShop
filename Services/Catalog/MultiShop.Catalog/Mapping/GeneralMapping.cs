using AutoMapper;
using MultiShop.Catalog.DTOs.CategoryDtos;
using MultiShop.Catalog.DTOs.ProductDetailDtos;
using MultiShop.Catalog.DTOs.ProductDtos;
using MultiShop.Catalog.DTOs.ProductImageDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			//Category Mappings
			CreateMap<Category , ResultCategoryDto>().ReverseMap();
			CreateMap<Category , CreateCategoryDto>().ReverseMap();
			CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			//Product Mappings
			CreateMap<Product , ResultProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, GetByIdProductDto>().ReverseMap();

			//ProductDetail Mappings
			CreateMap<ProductDetail , ResultProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();

			//ProductImage Mappings
			CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
			CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
			CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
		}
	}
}
