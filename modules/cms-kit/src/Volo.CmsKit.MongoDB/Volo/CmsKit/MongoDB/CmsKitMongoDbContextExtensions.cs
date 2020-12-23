﻿using System;
using Volo.Abp;
using Volo.Abp.MongoDB;
using Volo.CmsKit.Comments;
using Volo.CmsKit.Contents;
using Volo.CmsKit.Ratings;
using Volo.CmsKit.Reactions;
using Volo.CmsKit.Tags;
using Volo.CmsKit.Users;

namespace Volo.CmsKit.MongoDB
{
    public static class CmsKitMongoDbContextExtensions
    {
        public static void ConfigureCmsKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CmsKitMongoModelBuilderConfigurationOptions(
                CmsKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<CmsUser>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "Users";
            });

            builder.Entity<UserReaction>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "UserReactions";
            });

            builder.Entity<Comment>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "Comments";
            });
            
            builder.Entity<Rating>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "Ratings";
            });
            
            builder.Entity<Content>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "Contents";
            });
            
            builder.Entity<Tag>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "Tags";
            });
            
            builder.Entity<EntityTag>(x =>
            {
                x.CollectionName = CmsKitDbProperties.DbTablePrefix + "EntityTags";
            });
        }
    }
}
