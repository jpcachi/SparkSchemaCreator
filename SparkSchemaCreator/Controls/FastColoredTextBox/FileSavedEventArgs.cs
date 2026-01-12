using System;

namespace SparkSchemaCreator.Controls.FastColoredTextBox
{
    /// <summary>
    /// Custom event arguments for when a file is saved.
    /// </summary>
    public class FileSavedEventArgs : EventArgs
    {
        /// <summary>
        /// Public variable representing if the save was successful.
        /// </summary>
        public bool IsSaveSuccessful;

        /// <summary>
        /// Constructs an instance of <see cref="FileSavedEventArgs"/> with a default value of false for IsSaveSuccessful.
        /// </summary>
        public FileSavedEventArgs() {}

        /// <summary>
        /// Constructs an instance of <see cref="FileSavedEventArgs"/>.
        /// </summary>
        /// <param name="isSavedSuccessful"></param>
        public FileSavedEventArgs(bool isSavedSuccessful)
        {
            IsSaveSuccessful = isSavedSuccessful;
        }
    }
}
