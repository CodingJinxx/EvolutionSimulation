using Logic.Enums;

namespace Logic.Records;

public record Genome(Guid SourceId, ENeuronTypes SourceType, Guid SinkId, ENeuronTypes SinkType, float Weight);