using Autofac;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService<Customer, CustomerDto>>().SingleInstance();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<InstallmentOptionManager>().As<IInstallmentOptionService<InstallmentOption, InstallmentOptionDto>>().SingleInstance();
            builder.RegisterType<EFInstallmentOptionDal>().As<IInstallmentOptionDal>().SingleInstance();

            builder.RegisterType<InsuredPersonManager>().As<IInsuredPersonService<InsuredPerson, InsuredPersonDto>>().SingleInstance();
            builder.RegisterType<EFInsuredPersonDal>().As<IInsuredPersonDal>().SingleInstance();

            builder.RegisterType<InsuredPersonRelationshipManager>().As<IInsuredPersonRelationshipService<InsuredPersonRelationship, InsuredPersonRelationshipDto>>().SingleInstance();
            builder.RegisterType<EFInsuredPersonRelationshipDal>().As<IInsuredPersonRelationshipDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService<Order, OrderDto>>().SingleInstance();
            builder.RegisterType<EFOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<PaymentMethodManager>().As<IPaymentMethodService<PaymentMethod, PaymentMethodDto>>().SingleInstance();
            builder.RegisterType<EFPaymentMethodDal>().As<IPaymentMethodDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService<Product, ProductDto>>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
