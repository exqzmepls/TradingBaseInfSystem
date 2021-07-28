using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbConnection
{
    #region OKDP
    public class ProductClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductSubclass> Subclasses { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ProductSubclass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ClassId { get; set; }
        public virtual ProductClass Class { get; set; }

        public virtual ICollection<ProductGroup> Groups { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ProductGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SubclassId { get; set; }
        public virtual ProductSubclass Subclass { get; set; }

        public virtual ICollection<ProductSubgroup> Subgroups { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ProductSubgroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int GroupId { get; set; }
        public virtual ProductGroup Group { get; set; }

        public virtual ICollection<ProductKind> Kinds { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ProductKind
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SubgroupId { get; set; }
        public virtual ProductSubgroup Subgroup { get; set; }

        public virtual ICollection<ProductCategory> Categories { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ProductCategory : IComparable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int KindId { get; set; }
        public virtual ProductKind Kind { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public int CompareTo(object other)
        {
            if (other == null) return 1;

            if (other is ProductCategory category)
            {
                return Name.CompareTo(category.Name);
            }

            throw new ArgumentException("Object is not a ProductCategory");
        }

        public string View => Name;

        public override string ToString() => View;
    }
    #endregion

    #region OKEI
    public class Unit : IComparable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public string View => Name;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Unit unit) return Name.CompareTo(unit.Name);

            throw new ArgumentException("Object is not a Unit");
        }

        public override string ToString() => View;
    }
    #endregion

    #region subject field entities
    public enum PositionId : int
    {
        ADMIN = 10, ASSISTANT = 20, SENIOR_ASSISTANT = 21
    }

    public class Position : IComparable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public string View => Name;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Position position) return Name.CompareTo(position.Name);

            throw new ArgumentException("Object is not a Position");
        }

        public override string ToString() => View;
    }

    public abstract class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        public string View => Name;

        public override string ToString() => View;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Contact contact) return Name.CompareTo(contact.Name);

            throw new ArgumentException("Object is not a Contact");
        }
    }

    public class Customer : Contact
    {
        public virtual ICollection<Sale> Sales { get; set; }
    }

    public class Supplier : Contact
    {
        public virtual ICollection<Product> Products { get; set; }
    }

    public class Person : IComparable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public string MiddleName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Person person)
            {
                int surNameComp = Surname.CompareTo(person.Surname);
                if (surNameComp == 0)
                {
                    int nameComp = Name.CompareTo(person.Name);
                    if (nameComp == 0)
                    {
                        return MiddleName.CompareTo(person.MiddleName);
                    }
                    return nameComp;
                }
                return surNameComp;
            }
            else throw new ArgumentException("Object is not a Person");
        }

        public string View => $"{Surname} {Name} {MiddleName} ({Id})";

        public override string ToString()
        {
            return View;
        }
    }

    public class Employee : IComparable
    {
        public int Id { get; set; }

        public DateTime EntranceDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public string View => $"{Position}: {Person}";

        public override string ToString()
        {
            return View;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Employee employee)
            {
                int posCompare = Position.CompareTo(employee.Position);
                if (posCompare == 0)
                {
                    return Person.CompareTo(employee.Person);
                }
                else return posCompare;
            }

            throw new ArgumentException("Object is not a Employee");
        }
    }

    public class Product : IComparable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public virtual ICollection<ProductPrice> Prices { get; set; }

        public ProductPrice CurrentPrice => PriceOnDate(DateTime.Now.Date);

        public bool ContainsPriceOnDate(DateTime date)
        {
            return Prices.Where(x => x.SettingDate.Date == date.Date).Any();
        }

        public ProductPrice PriceOnDate(DateTime date)
        {
            List<ProductPrice> prices = Prices.Where(x => x.SettingDate <= date.Date).ToList();
            if (prices.Any())
            {
                DateTime settingDate = prices.Max(x => x.SettingDate);
                return prices.Where(x => x.SettingDate == settingDate).FirstOrDefault();
            }
            else return null;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Product product) return Name.CompareTo(product.Name);

            throw new ArgumentException("Object is not a Product");
        }

        public string View => Name;

        public override string ToString() => View;
    }

    public class ProductPrice : IComparable
    {
        public int Id { get; set; }

        public double ValuePerOneUnit { get; set; }

        public DateTime SettingDate { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<SoldProduct> SoldProducts { get; set; }

        public string View => $"{ValuePerOneUnit} руб.";

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is ProductPrice price) return ValuePerOneUnit.CompareTo(price.ValuePerOneUnit);

            throw new ArgumentException("Object is not a ProductPrice");
        }

        public override string ToString() => View;
    }

    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<SoldProduct> SoldProducts { get; set; }

        public SoldProduct Contains(int priceId)
        {
            return SoldProducts.Where(x => x.ProductPriceId == priceId)?.First();
        }

        public double? Total => SoldProducts?.Sum(x => x.ProductPrice.ValuePerOneUnit * x.Amount);

        public string View => $"Продажа {Id}";

        public override string ToString() => View;
    }

    public class SoldProduct
    {
        [Key]
        [Column(Order = 1)]
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductPriceId { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }

        public double Amount { get; set; }

        public double Price => ProductPrice.ValuePerOneUnit;

        public double Total => Price * Amount;

        public string ProductView => ProductPrice.Product.View;
    }
    #endregion
}
