using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            //EfRentalDal ile car_id daha önceden kullanılmış mı kontrol etmem gerek ama EfRentalDal'ı nasıl
            //burada gönderebileceğimi bulamadım. ValidationAscpect'in constructure'ı ile göndermeye çalışıp 
            //Activator.CreateInstance'da kullanmayı düşündüm ama ValidationAspect annotationında non-static 
            //parametre istediğini söyledi. _rentalDal'ı nasıl göndereceğimi bilemediğim için yapamadım.
        }
    }
}
