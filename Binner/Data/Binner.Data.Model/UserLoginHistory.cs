﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Binner.Data.Model
{
#if INITIALCREATE
    /// <summary>
    /// A user login entry
    /// </summary>
    public class UserLoginHistory : IEntity, IOptionalUserData
    {
        /// <summary>
        /// User Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserLoginHistoryId { get; set; }

        /// <summary>
        /// User who logged in
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Associated organization
        /// </summary>
        public int? OrganizationId { get; set; }

        /// <summary>
        /// Email address used to login
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// True if authentication was successful
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// True if user was allowed to login
        /// </summary>
        public bool CanLogin { get; set; }

        /// <summary>
        /// Error message if applicable
        /// </summary>
        public string? Message { get; set; }

        public DateTime DateCreatedUtc { get; set; }

        public DateTime DateModifiedUtc { get; set; }

        /// <summary>
        /// The ReCaptcha score during login
        /// </summary>
        public double? ReCaptchaScore { get; set; }

        /// <summary>
        /// Ip address who created the account
        /// </summary>
        public long Ip { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
#endif
}
