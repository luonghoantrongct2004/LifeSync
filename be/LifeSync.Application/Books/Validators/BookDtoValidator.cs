using FluentValidation;
using LifeSync.Application.Books.DTOs;
using Microsoft.Extensions.Localization;

namespace LifeSync.Application.Books.Validators;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator(IStringLocalizer<BookDtoValidator> localizer)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(localizer["TitleRequired"])
            .MaximumLength(200).WithMessage(localizer["TitleMaxLength"]);
        RuleFor(x => x.Author)
            .MaximumLength(100).WithMessage(localizer["AuthorMaxLength"]);
        RuleFor(x => x.Language)
            .NotEmpty().WithMessage(localizer["LanguageRequired"])
            .Must(lang => lang == "en" || lang == "vi").WithMessage(localizer["LanguageAllowed"]);
        RuleFor(x => x.PdfUrl)
            .NotEmpty().WithMessage(localizer["PdfUrlRequired"])
            .MaximumLength(500).WithMessage(localizer["PdfUrlMaxLength"])
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage(localizer["PdfUrlValid"]);
    }
} 