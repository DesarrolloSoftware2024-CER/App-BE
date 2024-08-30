using Watchly.Samples;
using Xunit;

namespace Watchly.EntityFrameworkCore.Domains;

[Collection(WatchlyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<WatchlyEntityFrameworkCoreTestModule>
{

}
