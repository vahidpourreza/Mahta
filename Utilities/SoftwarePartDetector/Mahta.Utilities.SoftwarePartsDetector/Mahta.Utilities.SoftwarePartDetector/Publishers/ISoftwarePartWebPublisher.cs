using Mahta.Utilities.SoftwarePartDetector.DataModel;

namespace Mahta.Utilities.SoftwarePartDetector.Publishers;

public interface ISoftwarePartPublisher
{
    Task PublishAsync(SoftwarePart softwarePart);
}