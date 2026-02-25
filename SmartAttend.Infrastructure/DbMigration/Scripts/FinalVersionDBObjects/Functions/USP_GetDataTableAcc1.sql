-- FUNCTION: public.usp_getdatatableacc1(integer, bigint, integer, integer, timestamp without time zone, timestamp without time zone)

-- DROP FUNCTION IF EXISTS public.usp_getdatatableacc1(integer, bigint, integer, integer, timestamp without time zone, timestamp without time zone);

CREATE OR REPLACE FUNCTION public.usp_getdatatableacc1(
	p_accountid integer,
	p_deviceid bigint,
	p_pagenumber integer,
	p_pagesize integer,
	p_fromdate timestamp without time zone,
	p_todate timestamp without time zone)
    RETURNS TABLE("Id" integer, "DeviceId" bigint, "AccountId" integer, "DeviceDataUserMapId" integer, "InputName" text, "Message" text, "CustomMessage" text, "ContactFromHours" text, "ContactToHours" text, "Reminder" integer, "SentDate" timestamp with time zone, "IsNotify" boolean, "IsActive" boolean, "EntityType" integer, "CompletedReason" text, "CreatedDate" timestamp with time zone, "UpdatedDate" timestamp with time zone, "RowNumber" bigint) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN

    IF (p_accountid > 0 AND p_deviceid = 0 AND p_fromdate IS NULL) THEN
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS rownumber
        FROM "Notifications" n
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = false
          AND n."AccountId" = p_accountid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0)
        LIMIT p_pagesize;

    ELSIF (p_accountid > 0 AND p_deviceid > 0 AND p_fromdate IS NULL) THEN
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS rownumber
        FROM "Notifications" n
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = false
          AND n."AccountId" = p_accountid
          AND n."DeviceId" = p_deviceid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0)
        LIMIT p_pagesize;

    ELSIF (p_accountid > 0 AND p_deviceid > 0 AND p_fromdate IS NOT NULL) THEN
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS rownumber
        FROM "Notifications" n
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = false
          AND n."AccountId" = p_accountid
          AND n."DeviceId" = p_deviceid
          AND n."CreatedDate" BETWEEN p_fromdate AND p_todate
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0)
        LIMIT p_pagesize;

    ELSE
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS rownumber
        FROM "Notifications" n
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = false
          AND n."AccountId" = p_accountid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0)
        LIMIT p_pagesize;
    END IF;

END;
$BODY$;

ALTER FUNCTION public.usp_getdatatableacc1(integer, bigint, integer, integer, timestamp without time zone, timestamp without time zone)
    OWNER TO sadashboard;
