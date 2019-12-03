using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class MovePointerRightCommand : ITechnicalCommand
    {
        Pointer pointer;

        public MovePointerRightCommand(Pointer pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            pointer.MoveRight();
        }
    }
}
