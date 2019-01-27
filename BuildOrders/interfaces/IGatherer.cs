namespace BuildOrders
{
    interface IGatherer
    {
        Resource resourceGathering { get; set; }
        bool idle { get; set; }

        void StopGathering();
        void GatherResource(Resource resource);
    }
}
