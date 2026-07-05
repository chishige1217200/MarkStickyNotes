namespace MarkStickyNotes.Entities
{
    /// <summary>
    /// 順序付けられたエンティティの抽象基底クラス
    /// </summary>
    public abstract class OrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
