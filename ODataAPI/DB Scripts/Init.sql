-- Table: public.activity
DROP TABLE IF EXISTS public.activity;
CREATE TABLE IF NOT EXISTS public.activity
(
    activityid uuid NOT NULL,
    name character varying(500) COLLATE pg_catalog."default"
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public.activity
    OWNER to postgres;
