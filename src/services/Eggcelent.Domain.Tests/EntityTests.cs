using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcelent.Domain.Tests
{
    public class EntityTests
    {
        public class TestEntity : Entity
        {
            public TestEntity()
            {

            }

            public TestEntity(Guid id) : base(id)
            {

            }
        }

        public class DifferentTypeEntity : Entity { }

        [Fact]
        public void GetHashCode_setting_identifier_should_return_expected_hash_code()
        {
            var identifier = Guid.NewGuid();
            var expectedHashCode = identifier.GetHashCode() ^ 31;

            var entity = new TestEntity(identifier);

            Assert.Equal(expectedHashCode, entity.GetHashCode());
        }

        [Fact]
        public void GetHashCode_not_setting_id_should_not_throw()
        {
            var entity = new TestEntity();

            var exception = Record.Exception(() => entity.GetHashCode());

            Assert.Null(exception);
        }

        [Fact]
        public void Equals_same_id_should_return_true()
        {
            var id = Guid.NewGuid();

            var entity = new TestEntity(id);
            var otherEntity = new TestEntity(id);

            Assert.True(entity.Equals(otherEntity));
        }

        [Fact]
        public void Equals_same_reference_should_return_true()
        {
            var entity = new TestEntity();

            var otherEntity = entity;

            Assert.True(entity.Equals(otherEntity));
        }

        [Fact]
        public void Equals_different_id_should_return_false()
        {
            var id = Guid.NewGuid();
            var differentId = Guid.NewGuid();

            var entity = new TestEntity(id);
            var otherEntity = new TestEntity(differentId);

            Assert.False(entity.Equals(otherEntity));
        }

        [Fact]
        public void Equals_different_entity_type_should_return_false()
        {
            var entity = new TestEntity();
            var differentTypeEntity = new DifferentTypeEntity();

            Assert.False(entity.Equals(differentTypeEntity));
        }

        [Fact]
        public void Equals_null_entity_should_return_false()
        {
            var entity = new TestEntity();
            TestEntity? otherEntity = null;

            Assert.False(entity.Equals(otherEntity));
        }
    }
}
