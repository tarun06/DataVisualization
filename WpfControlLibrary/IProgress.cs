using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlLibrary
{
    public interface IProgress
    {
        void Report(int progress);

        void TryClose();

        void TryShow();
    }
}
