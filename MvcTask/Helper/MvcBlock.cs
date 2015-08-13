using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Helper
{
    public class MvcBlock : IDisposable
    {

        private bool _disposed;
        private readonly FormContext _originalFormContext;
        private readonly ViewContext _viewContext;
        private readonly TextWriter _writer;

        public MvcBlock(ViewContext viewContext, string title)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }

            _viewContext = viewContext;
            _writer = viewContext.Writer;
            _originalFormContext = viewContext.FormContext;
            viewContext.FormContext = new FormContext();

            Begin(title);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Begin(string title)
        {
            _writer.Write("<div class=\"sidebar_box\"><h3>{0}</h3>", title);
        }

        private void End()
        {
            _writer.Write("<div class=\"cleaner\"></div></div>");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            End();

            if (_viewContext == null) return;
            _viewContext.OutputClientValidation();
            _viewContext.FormContext = _originalFormContext;
        }

        public void EndForm()
        {
            Dispose(true);
        }
    }
}