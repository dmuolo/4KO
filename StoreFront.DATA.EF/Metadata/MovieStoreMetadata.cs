using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF
{
    #region Actor Metadata

    public class ActorMetadata
    {
        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* First Name must be 20 characters or less *")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* Last Name must be 20 characters or less *")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }

    [MetadataType(typeof(ActorMetadata))]

    public partial class Actor
    {
        [Display(Name = "Actor")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    #endregion

    #region AspectRatio Metadata

    public class AspectRatioMetadata
    {
        [Display(Name = "Aspect Ratio")]
        [StringLength(30, ErrorMessage = "* Aspect Ratio must be 30 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string AspectRatio1 { get; set; }
    }

    [MetadataType(typeof(AspectRatioMetadata))]

    public partial class AspectRatio
    {

    }

    #endregion

    #region Category Metadata

    public class CategoryMetadata
    {
        [Display(Name = "Category")]
        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* Category must be 20 characters or less *")]
        public string Category1 { get; set; }
    }

    [MetadataType(typeof(CategoryMetadata))]

    public partial class Category
    {

    }

    #endregion

    #region Country Metadata

    public class CountryMetadata
    {
        [Display(Name = "Country")]
        [StringLength(50, ErrorMessage = "* Country must be 50 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string Country1 { get; set; }
    }

    [MetadataType(typeof(CountryMetadata))]

    public partial class Country
    {

    }

    #endregion

    #region Department Metadata

    public class DepartmentMetadata
    {
        [Display(Name = "Department")]
        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* Department must be 20 characters or less *")]
        public string Department1 { get; set; }
    }

    [MetadataType(typeof(DepartmentMetadata))]

    public partial class Department
    {

    }

    #endregion

    #region Director Metadata

    public class DirectorMetadata
    {
        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* First Name must be 20 characters or less *")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* Last Name must be 20 characters or less *")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }

    [MetadataType(typeof(DirectorMetadata))]

    public partial class Director
    {
        [Display(Name = "Director")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    #endregion

    #region Employee Metadata

    public class EmployeeMetadata
    {
        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* First Name must be 20 characters or less *")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Required *")]
        [StringLength(20, ErrorMessage = "* Last Name must be 20 characters or less *")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[Not Given")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[Not Given")]
        public Nullable<System.DateTime> HireDate { get; set; }

        [StringLength(60, ErrorMessage = "* Address must be 60 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "* City must be 15 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "* Region must be 15 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string Region { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "* City must be 10 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string PostalCode { get; set; }

        [StringLength(20, ErrorMessage = "* Country must be 20 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "* Phone must be 24 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string Phone { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "* Value must be a valid number (0 or larger) *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public Nullable<int> ReportsTo { get; set; }

        [Required(ErrorMessage = "* Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Value must be a valid number (0 or larger) *")]
        public int DepartmentID { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]

    public partial class Employee
    {
        [Display(Name = "Employee")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    #endregion

    #region Genre Metadata

    public class GenreMetadata
    {
        [Display(Name = "Genre")]
        [StringLength(50, ErrorMessage = "* Genre must be 50 characters or less *")]
        [Required(ErrorMessage = "* Genre is Required *")]
        public string GenreName { get; set; }
    }

    [MetadataType(typeof(GenreMetadata))]

    public partial class Genre
    {

    }

    #endregion

    #region Language Metadata

    public class LanguageMetadata
    {
        [Display(Name = "Language")]
        [StringLength(30, ErrorMessage = "* Language must be 30 characters or less *")]
        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public string Language1 { get; set; }
    }

    [MetadataType(typeof(LanguageMetadata))]

    public partial class Language
    {

    }

    #endregion

    #region MovieActor Metadata

    public class MovieActorMetadata
    {
        [Display(Name = "Movie ID")]
        [Required(ErrorMessage = "* Movie ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Movie ID must be a valid number (0 or larger) *")]
        public int MovieID { get; set; }

        [Display(Name = "Actor ID")]
        [Required(ErrorMessage = "* Actor ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Actor ID must be a valid number (0 or larger) *")]
        public int ActorID { get; set; }
    }

    [MetadataType(typeof(MovieActorMetadata))]

    public partial class MovieActor
    {

    }

    #endregion

    #region MovieRating Metadata

    public class MovieRatingMetadata
    {
        [Display(Name = "Movie Rating")]
        [Required(ErrorMessage = "* Movie Rating is Required *")]
        [StringLength(10, ErrorMessage = "* Movie Rating must be 10 characters or less *")]
        public string MovieRating1 { get; set; }
    }

    [MetadataType(typeof(MovieRatingMetadata))]

    public partial class MovieRating
    {

    }

    #endregion

    #region MovieStatus Metadata

    public class MovieStatusMetadata
    {
        [Required(ErrorMessage = "* Status is Required *")]
        [StringLength(25, ErrorMessage = "* The value must be 25 characters or less *")]
        public string Status { get; set; }

        [StringLength(100, ErrorMessage = "* Notes must be 100 characters or less *")]
        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[None Given]")]
        public string Notes { get; set; }
    }

    [MetadataType(typeof(MovieStatusMetadata))]

    public partial class MovieStatu
    {

    }

    #endregion

    #region MovieTitle Metadata

    public class MovieTitleMetadata
    {
        [Display(Name = "Movie")]
        [Required(ErrorMessage = "* Movie Title is Required *")]
        [StringLength(100, ErrorMessage = "* Movie Title must be 100 characters or less *")]
        public string MovieTitle1 { get; set; }

        [Display(Name = "Genre ID")]
        [Required(ErrorMessage = "* Genre ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Genre ID must be a valid number (0 or larger) *")]
        public int GenreID { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "* Value must be a valid number (0 or larger) *")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[N/A]")]
        public Nullable<decimal> Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "* Units in Stock must be a valid number (0 or larger) *")]
        [Required(ErrorMessage = "* Units in Stock is Required *")]
        [Display(Name = "Units in Stock")]
        public int UnitsInStock { get; set; }

        [Display(Name = "Release Year")]
        [Required(ErrorMessage = "* Release Year is Required *")]
        public short ReleaseYear { get; set; }

        [Display(Name = "Movie Rating ID")]
        [Required(ErrorMessage = "* Movie Rating ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Movie Rating ID must be a valid number (0 or larger) *")]
        public int MovieRatingID { get; set; }

        [Required(ErrorMessage = "* Runtime is Required *")]
        [StringLength(30, ErrorMessage = "* Runtime must be 30 characters or less *")]
        public string Runtime { get; set; }

        [Display(Name = "Director ID")]
        [Required(ErrorMessage = "* Director ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Director ID must be a valid number (0 or larger) *")]
        public int DirectorID { get; set; }

        [Display(Name = "Country ID")]
        [Required(ErrorMessage = "* Country ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Country ID must be a valid number (0 or larger) *")]
        public Nullable<int> CountryID { get; set; }

        [Display(Name = "Aspect Ratio ID")]
        [Required(ErrorMessage = "* Aspect Ratio ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Aspect Ratio ID must be a valid number (0 or larger) *")]
        public Nullable<int> AspectRatioID { get; set; }

        [DisplayFormat(NullDisplayText = "[Not Given]")]
        public Nullable<bool> IsColor { get; set; }

        [Display(Name = "Language ID")]
        [Required(ErrorMessage = "* Language ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Language ID must be a valid number (0 or larger) *")]
        public Nullable<int> LanguageID { get; set; }

        [StringLength(500, ErrorMessage = "* Description must be 500 characters or less *")]
        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Description { get; set; }

        //All validation to be done manually inside the controller
        public string Image { get; set; }

        [Display(Name = "Status ID")]
        [Required(ErrorMessage = "* Status ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Status ID must be a valid number (0 or larger) *")]
        public int StatusID { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "* Category ID is Required *")]
        [Range(0, int.MaxValue, ErrorMessage = "* Category ID must be a valid number (0 or larger) *")]
        public int CategoryID { get; set; }
    }

    [MetadataType(typeof(MovieTitleMetadata))]

    public partial class MovieTitle
    {

    }

    #endregion
}
