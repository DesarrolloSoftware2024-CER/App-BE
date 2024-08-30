using Watchly.Samples;
using Xunit;

namespace Watchly.EntityFrameworkCore.Applications;

[Collection(WatchlyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<WatchlyEntityFrameworkCoreTestModule>
{

}
