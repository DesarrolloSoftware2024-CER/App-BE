using Xunit;

namespace Watchly.EntityFrameworkCore;

[CollectionDefinition(WatchlyTestConsts.CollectionDefinitionName)]
public class WatchlyEntityFrameworkCoreCollection : ICollectionFixture<WatchlyEntityFrameworkCoreFixture>
{

}
