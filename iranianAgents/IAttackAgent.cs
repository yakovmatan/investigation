using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.iranianAgents
{
    internal interface IAttackAgent
    {
        int CounterAttack {get; set;}
        void Attack();
    }
}
