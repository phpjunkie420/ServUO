using System;
using Server.Targeting;

namespace Server.Spells.Second
{
    public class HarmSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Harm", "An Mani",
            212,
            9001,
            Reagent.Nightshade,
            Reagent.SpidersSilk);
        public HarmSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle
        {
            get
            {
                return SpellCircle.Second;
            }
        }
        public override bool DelayedDamage
        {
            get
            {
                return false;
            }
        }
        public override void OnCast()
        {
            this.Caster.Target = new InternalTarget(this);
        }

        public override double GetSlayerDamageScalar(Mobile target)
        {
            return 1.0; //This spell isn't affected by slayer spellbooks
        }

        public void Target(IDamageable m)
        {
            Mobile mob = m as Mobile;

            if (!this.Caster.CanSee(m))
            {
                this.Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (this.CheckHSequence(m))
            {
                SpellHelper.Turn(this.Caster, m);
                Mobile source = this.Caster;

                SpellHelper.CheckReflect((int)this.Circle, ref source, ref m);

                double damage = GetNewAosDamage(17, 1, 5, m);

                if (!this.Caster.InRange(m, 2))
                    damage *= 0.25; // 1/4 damage at > 2 tile range
                else if (!this.Caster.InRange(m, 1))
                    damage *= 0.50; // 1/2 damage at 2 tile range

                if (mob != null)
                {
                    mob.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);
                    mob.PlaySound(0x0FC);
                }
                else
                {
                    Effects.SendLocationParticles(m, 0x374A, 10, 30, 1153, 2, 5013, 0);
                    Effects.PlaySound(m.Location, m.Map, 0x0FC);
                }

                if (damage > 0)
                {
                    SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);
                }
            }

            this.FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly HarmSpell m_Owner;
            public InternalTarget(HarmSpell owner)
                : base(10, false, TargetFlags.Harmful)
            {
                this.m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is IDamageable)
                {
                    this.m_Owner.Target((IDamageable)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                this.m_Owner.FinishSequence();
            }
        }
    }
}
