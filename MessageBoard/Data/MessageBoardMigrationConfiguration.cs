using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {

        public MessageBoardMigrationConfiguration()
        {

            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
                base.Seed(context);
        }
    }
}
