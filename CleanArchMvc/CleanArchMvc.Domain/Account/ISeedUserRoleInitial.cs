namespace CleanArchMvc.Domain.Account
{
    /// <summary>
    /// The seed user role initial.
    /// </summary>
    public interface ISeedUserRoleInitial
    {
        /// <summary>
        /// Seeds the users.
        /// </summary>
        void SeedUsers();
        /// <summary>
        /// Seeds the roles.
        /// </summary>
        void SeedRoles();
    }
}
