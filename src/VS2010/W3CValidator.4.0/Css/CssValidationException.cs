using System;

namespace W3CValidator.Css
{
  /// <summary>
  ///   <para>Exception that indicates an error during the process of CSS document validation through W3C CSS validation web service.</para>
  /// </summary>
  public sealed class CssValidationException : ValidationException
  {
    /// <summary>
    ///   <para>Initializes a new instance of the exception with a specified error message and a reference to the inner exception that is the cause of this exception.</para>
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="message"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="message"/> is <see cref="string.Empty"/> string.</exception>
    public CssValidationException(string message, Exception innerException = null) : base(message, innerException)
    {
    }
  }
}