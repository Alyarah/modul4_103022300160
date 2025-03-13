using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4_103022300160
{
    internal class FanLaptop
    {
        public enum FanState {Quiet, Balance, Performance, Turbo }; 
        public enum Trigger {Mode_Up, Mode_Down, Turbo_Shortcut };

        class transition
            {
                public FanState prevState;
                public FanState nextState;
                public Trigger trigger;
                
                public transition(FanState prevState, FanState nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
            }
        transition[] transitions =
        {
            new transition(FanState.Quiet, FanState.Turbo, Trigger.Turbo_Shortcut),
            new transition(FanState.Turbo, FanState.Quiet, Trigger.Turbo_Shortcut),
            new transition(FanState.Quiet, FanState.Balance, Trigger.Mode_Up),
            new transition(FanState.Balance, FanState.Quiet, Trigger.Mode_Down),
            new transition(FanState.Balance, FanState.Performance, Trigger.Mode_Up),
            new transition(FanState.Performance, FanState.Balance, Trigger.Mode_Down),
            new transition(FanState.Performance, FanState.Turbo, Trigger.Mode_Up),
            new transition(FanState.Turbo, FanState.Performance, Trigger.Mode_Down),
        };
        public FanState currentState;
        public FanState getNextState(FanState prevState, Trigger trigger)
        {
            FanState nextState = prevState;
            for (int i = 0; i < transitions.Length; i++) {
                if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
                    nextState = transitions[i].nextState;
            }
            return nextState;
        }
        public void activatedTrigger(Trigger trigger)
        {
            FanState prevState = currentState;
            currentState = getNextState(currentState, trigger);

            Console.WriteLine("Fan" + prevState + " berubah menjadi " + currentState);
        }

        public void simulasi()
        {
            FanLaptop fanLaptop = new FanLaptop();
            fanLaptop.activatedTrigger(Trigger.Mode_Up);
            fanLaptop.activatedTrigger(Trigger.Mode_Up);
            fanLaptop.activatedTrigger(Trigger.Mode_Up);
            fanLaptop.activatedTrigger(Trigger.Mode_Down);
            fanLaptop.activatedTrigger(Trigger.Mode_Down);
            fanLaptop.activatedTrigger(Trigger.Mode_Down);
            fanLaptop.activatedTrigger(Trigger.Turbo_Shortcut);
            fanLaptop.activatedTrigger(Trigger.Turbo_Shortcut);
        }
    }
}

    
