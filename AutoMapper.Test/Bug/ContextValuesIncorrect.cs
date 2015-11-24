﻿using AutoMapper.Should;
using NUnit.Framework;

namespace AutoMapper.Test.Bug
{
    namespace ContextValuesIncorrect
    {
        public class Foo
        {
            public int? Value { get; set; }
            public int? Value2 { get; set; }
        }

        public class FooDto
        {
            public int? Value { get; set; }
            public int? Value2 { get; set; }
        }

        [TestFixture]
        public class When_conditionally_skipping_null_destination_values : AutoMapperSpecBase
        {
            private FooDto _destination;

            protected override void Establish_context()
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Foo, FooDto>()
                        .ForAllMembers(opt => opt.Condition(ctx => ctx.DestinationValue == null));
                });
            }
            protected override void Because_of()
            {
                var source = new Foo
                {
                    Value = 3,
                    Value2 = 4
                };
                _destination = new FooDto
                {
                    Value = 5
                };

                Mapper.Map(source, _destination);
            }

            [Test]
            public void Should_map_the_null_value()
            {
                _destination.Value2.ShouldEqual(4);
            }

            [Test]
            public void Should_leave_the_non_null_value_alone()
            {
                _destination.Value.ShouldEqual(5);
            }
        }
    }
}