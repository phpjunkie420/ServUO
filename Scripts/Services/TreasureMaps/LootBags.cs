using System;

namespace Server.Items
{
    [FlipableAttribute(0xA333, 0xA334)]
    public class BagOfGems : Bag
    {
        public override int LabelNumber { get { return 1048032; } } // a bag

        public BagOfGems()
        {
            ItemID = 0xA333;
        }

        public BagOfGems(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }

    [FlipableAttribute(0xA331, 0xA332)]
    public class BagOfGold : Bag
    {
        public override int LabelNumber { get { return 1048032; } } // a bag

        public BagOfGold()
        {
            ItemID = 0xA331;
        }

        public BagOfGold(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }

    [FlipableAttribute(0xA32F, 0xA330)]
    public class BagOfRegs : Bag
    {
        public override int LabelNumber { get { return 1048032; } } // a bag

        public BagOfRegs()
        {
            ItemID = 0xA32F;
        }

        public BagOfRegs(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
