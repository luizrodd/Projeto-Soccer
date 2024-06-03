using Domain.Validation;
using System.Linq.Expressions;

namespace Domain.Entitites
{
    public class News
    {
        public News(string title, string image, string source)
        {
            ValidateDomain(title, source);
            Title = title;
            Image = image;
            Source = source;
        }
        public News(string title, string image, string source, Guid teamId)
        {
            ValidateDomain(title, source);
            Title = title;
            Image = image;
            Source = source;
            TeamId = teamId;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public void ValidateDomain(string title, string source)
        {
            DomainExceptionValidation.When(title is null,
                "Title cannot be null");
            DomainExceptionValidation.When(title.Length > 50,
                "Title cannot be longer than 50 characters");
         
            DomainExceptionValidation.When(source is null,
                "Source cannot be null");
        } 

    }
    
}
