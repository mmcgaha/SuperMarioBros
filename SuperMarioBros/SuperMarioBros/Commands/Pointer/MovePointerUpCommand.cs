using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class MovePointerUpCommand : ITechnicalCommand
    {
        Pointer pointer;

        public MovePointerUpCommand(Pointer pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            pointer.MoveUp();
        }
    }
}
