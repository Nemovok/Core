using System;
using System.Collections.Generic;
using System.Linq;

using Core.Application.Exceptions.Interfaces;

using FluentValidation.Results;

namespace Core.Application.Exceptions
{
    public class CoreValidationException : Exception, ICoreException
    {
        private readonly IDictionary<string, IEnumerable<string>> _failures;

        public CoreValidationException()
            : base("One or more validation failures have occured.")
        {
            _failures = new Dictionary<string, IEnumerable<string>>();
        }

        public CoreValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures.GroupBy(x => x.PropertyName, y => y.ErrorMessage);
            foreach (var failureGroup in failureGroups)
            {
                _failures.Add(failureGroup.Key, failureGroup.AsEnumerable());
            }
        }
    }
}
