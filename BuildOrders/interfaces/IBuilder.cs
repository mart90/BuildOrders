namespace BuildOrders
{
    public interface IBuilder
    {
        ConstBuilding buildingQueued { get; set; }
        int timer { get; set; }

        void MakeBuilding(ConstBuilding building);
        bool ConstructionFinished();
        void ClearQueue();
    }
}
