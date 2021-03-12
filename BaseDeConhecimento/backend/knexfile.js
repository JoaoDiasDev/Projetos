// Update with your config settings.

module.exports = {
  client: "postgresql",
  connection: {
    database: "base_de_conhecimento",
    user: "postgres",
    password: "Matheus321*",
  },
  pool: {
    min: 2,
    max: 10,
  },
  migrations: {
    tableName: "knex_migrations",
  },
};
