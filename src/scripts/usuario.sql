-- Table: usuario

-- DROP TABLE usuario;

CREATE TABLE usuario
(
  usuarioid serial NOT NULL,
  nome character varying(40),
  senha character varying(8),
  email character varying(40),
  CONSTRAINT usuario_pkey PRIMARY KEY (usuarioid)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE usuario
  OWNER TO postgres;
