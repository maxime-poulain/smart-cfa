﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart.FA.Catalog.Showcase.Infrastructure.Migrations
{
    public partial class Filter_BlackListed_Trainer_And_Training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainerDetails]
                                   AS
                                   SELECT trainer.Id
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Biography
                                       ,trainer.Title
                                       ,trainer.Email
                                       ,trainer.ProfileImagePath
                                       ,socialNetwork.SocialNetworkId
                                       ,socialNetwork.UrlToProfile
                                   FROM [Cfa].Trainer trainer
                                       LEFT JOIN Cfa.TrainerSocialNetwork socialNetwork
                                       ON trainer.Id = socialNetwork.TrainerId
                                       INNER JOIN Cfa.TrainerAssignment assignment
                                       ON assignment.TrainerId = trainer.Id
                                       INNER JOIn Cfa.Training training
                                       ON training.Id = assignment.TrainingId
                                       INNER JOIN Cfa.TrainingStatusType trainingStatusType
                                       ON trainingStatusType.Id = training.TrainingStatusTypeId
                                       LEFT JOIN [Cfa].[BlackListedTrainer] blacklist
                                       ON blacklist.TrainerId = trainer.Id
                                   WHERE TrainingStatusType.Name = 'Published' AND
	                                     blacklist.TrainerId IS NULL
                                   GROUP BY trainer.Id
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Biography
                                       ,trainer.Title
                                       ,trainer.Email
                                       ,trainer.ProfileImagePath
                                       ,socialNetwork.SocialNetworkId
                                       ,socialNetwork.UrlToProfile");

            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainerList]
                                   AS
                                   SELECT
                                       trainer.Id
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Title
                                       ,trainer.ProfileImagePath
	                                   ,count(assignment.TrainingId) As TrainingCount
                                   FROM Cfa.Trainer trainer
                                       INNER JOIN Cfa.TrainerAssignment assignment
                                       ON assignment.TrainerId = trainer.Id
                                       INNER JOIN Cfa.Training training ON
                                       assignment.TrainingId = training.Id
                                       INNER JOIN Cfa.TrainingStatusType  TrainingStatusType
                                       ON TrainingStatusType.Id = training.TrainingStatusTypeId
                                       LEFT JOIN [Cfa].[BlackListedTrainer] blacklist
                                       ON blacklist.TrainerId = trainer.Id
                                   WHERE TrainingStatusType.Name = 'Published' AND
	                                     blacklist.TrainerId IS NULL
                                   GROUP BY trainer.Id, trainer.FirstName, trainer.LastName, trainer.Title, trainer.ProfileImagePath
                                   HAVING count(assignment.TrainingId) >= 1");

            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainingDetails]
                                   AS
                                   SELECT training.Id
                                       ,details.Title
                                       ,details.Methodology
                                       ,details.Goal
                                       ,details.PracticalModalities
                                       ,topic.TopicId
                                       ,details.Language
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Id AS TrainerId
                                       ,trainer.Title AS trainerTitle
                                       ,training.TrainingStatusTypeId
                                       ,trainer.ProfileImagePath
                                   FROM [Cfa].[Training] AS training
                                       INNER JOIN [Cfa].[TrainingLocalizedDetails] AS details
                                       ON training.Id = details.TrainingId
                                       INNER JOIN [Cfa].[TrainerAssignment] trainingTrainer
                                       ON training.Id = trainingTrainer.TrainingId
                                       INNER JOIN [Cfa].[Trainer] trainer
                                       ON trainingTrainer.TrainerId = trainer.Id
                                       INNER JOIN [Cfa].[TrainingTopic] topic
                                       ON training.Id = topic.TrainingId
                                       INNER JOIN Cfa.TrainingStatusType trainingStatusType
                                       ON trainingStatusType.Id = training.TrainingStatusTypeId
                                       LEFT JOIN [Cfa].[BlackListedTrainer] blacklist
                                       ON blacklist.TrainerId = trainer.Id
                                   WHERE TrainingStatusType.Name = 'Published' AND
	                                     blacklist.TrainerId IS NULL");

            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainingList]
                                    AS
                                    SELECT training.Id
                                        ,detail.Title
                                        ,detail.Language
                                        ,trainer.FirstName
                                        ,trainer.LastName
                                        ,category.TopicId
                                        ,training.TrainingStatusTypeId
                                        ,trainer.Id AS TrainerId
                                        ,detail.Goal
                                        ,detail.Methodology
                                    FROM [Cfa].[Training] AS training
                                        INNER JOIN [Cfa].[TrainingLocalizedDetails] AS detail
                                        ON training.Id = detail.TrainingId
                                        INNER JOIN [Cfa].[TrainingTopic] category
                                        ON training.Id = category.TrainingId
                                        INNER JOIN [Cfa].[TrainerAssignment] trainingTrainer
                                        ON training.Id = trainingTrainer.TrainingId
                                        INNER JOIN [Cfa].[Trainer] trainer
                                        ON trainingTrainer.TrainerId = trainer.Id
                                        INNER JOIN Cfa.TrainingStatusType trainingStatusType
                                        ON trainingStatusType.Id = training.TrainingStatusTypeId
                                        LEFT JOIN [Cfa].[BlackListedTrainer] blacklist
                                        ON blacklist.TrainerId = trainer.Id
                                    WHERE TrainingStatusType.Name = 'Published' AND
	                                      blacklist.TrainerId IS NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainerDetails]
                                   AS
                                   SELECT trainer.Id
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Biography
                                       ,trainer.Title
                                       ,trainer.Email
                                       ,trainer.ProfileImagePath
                                       ,socialNetwork.SocialNetworkId
                                       ,socialNetwork.UrlToProfile
                                   FROM [Cfa].Trainer trainer
                                       LEFT JOIN Cfa.TrainerSocialNetwork socialNetwork
                                       ON trainer.Id = socialNetwork.TrainerId
                                       INNER JOIN Cfa.TrainerAssignment assignment
                                       ON assignment.TrainerId = trainer.Id
                                       INNER JOIn Cfa.Training training
                                       ON training.Id = assignment.TrainingId
                                       INNER JOIN Cfa.TrainingStatusType trainingStatusType
                                       ON trainingStatusType.Id = training.TrainingStatusTypeId
                                   WHERE TrainingStatusType.Name = 'Published'
                                   GROUP BY trainer.Id
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Biography
                                       ,trainer.Title
                                       ,trainer.Email
                                       ,trainer.ProfileImagePath
                                       ,socialNetwork.SocialNetworkId
                                       ,socialNetwork.UrlToProfile");

            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainerList]
                                   AS
                                   SELECT
                                       trainer.Id
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Title
                                       ,trainer.ProfileImagePath
	                                   ,count(assignment.TrainingId) As TrainingCount
                                   FROM Cfa.Trainer trainer
                                       INNER JOIN Cfa.TrainerAssignment assignment
                                       ON assignment.TrainerId = trainer.Id
                                       INNER JOIN Cfa.Training training ON
                                       assignment.TrainingId = training.Id
                                       INNER JOIN Cfa.TrainingStatusType  TrainingStatusType
                                       ON TrainingStatusType.Id = training.TrainingStatusTypeId
                                   WHERE TrainingStatusType.Name = 'Published'
                                   GROUP BY trainer.Id, trainer.FirstName, trainer.LastName, trainer.Title, trainer.ProfileImagePath
                                   HAVING count(assignment.TrainingId) >= 1");

            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainingDetails]
                                   AS
                                   SELECT training.Id
                                       ,details.Title
                                       ,details.Methodology
                                       ,details.Goal
                                       ,details.PracticalModalities
                                       ,topic.TopicId
                                       ,details.Language
                                       ,trainer.FirstName
                                       ,trainer.LastName
                                       ,trainer.Id AS TrainerId
                                       ,trainer.Title AS trainerTitle
                                       ,training.TrainingStatusTypeId
                                       ,trainer.ProfileImagePath
                                   FROM [Cfa].[Training] AS training
                                       INNER JOIN [Cfa].[TrainingLocalizedDetails] AS details
                                       ON training.Id = details.TrainingId
                                       INNER JOIN [Cfa].[TrainerAssignment] trainingTrainer
                                       ON training.Id = trainingTrainer.TrainingId
                                       INNER JOIN [Cfa].[Trainer] trainer
                                       ON trainingTrainer.TrainerId = trainer.Id
                                       INNER JOIN [Cfa].[TrainingTopic] topic
                                       ON training.Id = topic.TrainingId
                                       INNER JOIN Cfa.TrainingStatusType trainingStatusType
                                       ON trainingStatusType.Id = training.TrainingStatusTypeId
                                   WHERE TrainingStatusType.Name = 'Published'");

            migrationBuilder.Sql(@"ALTER VIEW [Cfa].[v_TrainingList]
                                    AS
                                    SELECT training.Id
                                        ,detail.Title
                                        ,detail.Language
                                        ,trainer.FirstName
                                        ,trainer.LastName
                                        ,category.TopicId
                                        ,training.TrainingStatusTypeId
                                        ,trainer.Id AS TrainerId
                                        ,detail.Goal
                                        ,detail.Methodology
                                    FROM [Cfa].[Training] AS training
                                        INNER JOIN [Cfa].[TrainingLocalizedDetails] AS detail
                                        ON training.Id = detail.TrainingId
                                        INNER JOIN [Cfa].[TrainingTopic] category
                                        ON training.Id = category.TrainingId
                                        INNER JOIN [Cfa].[TrainerAssignment] trainingTrainer
                                        ON training.Id = trainingTrainer.TrainingId
                                        INNER JOIN [Cfa].[Trainer] trainer
                                        ON trainingTrainer.TrainerId = trainer.Id
                                        INNER JOIN Cfa.TrainingStatusType trainingStatusType
                                        ON trainingStatusType.Id = training.TrainingStatusTypeId
                                    WHERE TrainingStatusType.Name = 'Published'");
        }
    }
}
