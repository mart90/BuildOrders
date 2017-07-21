using System;

namespace BuildOrders
{
    [Serializable]
    public class HomeCity : Building
    {        
        public ConstShipment shipmentQueued;

        public override void SetInitialAllowedTechs() { }

        public override void ClearQueue()
        {
            busy = false;
            timer = 0;
            shipmentQueued = null;
        }

        public void MakeShipment(ConstShipment shipment)
        {
            shipmentQueued = shipment;
            busy = true;
            timer = 40;
        }
    }
}
