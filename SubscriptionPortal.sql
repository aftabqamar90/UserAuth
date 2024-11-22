PGDMP  ;    7            
    |            SubscriptionPortal    17.0    17.0                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            	           1262    16389    SubscriptionPortal    DATABASE     �   CREATE DATABASE "SubscriptionPortal" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
 $   DROP DATABASE "SubscriptionPortal";
                     postgres    false            �            1255    16469 6   get_user_subscriptions(bigint, integer, integer, text)    FUNCTION     �  CREATE FUNCTION public.get_user_subscriptions(p_user_id bigint, p_page_size integer DEFAULT 10, p_page_number integer DEFAULT 1, p_search text DEFAULT NULL::text) RETURNS TABLE(subscription_id bigint, subscription_name character varying, start_date date)
    LANGUAGE sql
    AS $$
SELECT 
    s."Id" AS subscription_id,
    COALESCE(s."Name", 'No Name') AS subscription_name,
    us."StartDate"
FROM 
    public."Subscriptions" s
JOIN 
    "UserSubscriptions" us ON s."Id" = us."SubscriptionId"
WHERE 
    us."UserId" = p_user_id
    AND (p_search IS NULL OR s."Name" ILIKE '%' || p_search || '%')
   
ORDER BY 
    us."StartDate" DESC
LIMIT 
    p_page_size
OFFSET 
    (p_page_number - 1) * p_page_size;
$$;
 z   DROP FUNCTION public.get_user_subscriptions(p_user_id bigint, p_page_size integer, p_page_number integer, p_search text);
       public               postgres    false            �            1259    16402    Subscriptions    TABLE     f   CREATE TABLE public."Subscriptions" (
    "Id" bigint NOT NULL,
    "Name" character(100) NOT NULL
);
 #   DROP TABLE public."Subscriptions";
       public         heap r       postgres    false            �            1259    16401    Subscriptions_Id_seq    SEQUENCE        CREATE SEQUENCE public."Subscriptions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public."Subscriptions_Id_seq";
       public               postgres    false    220            
           0    0    Subscriptions_Id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public."Subscriptions_Id_seq" OWNED BY public."Subscriptions"."Id";
          public               postgres    false    219            �            1259    16391    User    TABLE     �   CREATE TABLE public."User" (
    "Id" bigint NOT NULL,
    "UserName" character(100) NOT NULL,
    "UserPassword" character(255)
);
    DROP TABLE public."User";
       public         heap r       postgres    false            �            1259    16409    UserSubscriptions    TABLE     �   CREATE TABLE public."UserSubscriptions" (
    "Id" bigint NOT NULL,
    "UserId" bigint NOT NULL,
    "SubscriptionId" bigint NOT NULL,
    "StartDate" date
);
 '   DROP TABLE public."UserSubscriptions";
       public         heap r       postgres    false            �            1259    16408    UserSubscriptions_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."UserSubscriptions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public."UserSubscriptions_Id_seq";
       public               postgres    false    222                       0    0    UserSubscriptions_Id_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public."UserSubscriptions_Id_seq" OWNED BY public."UserSubscriptions"."Id";
          public               postgres    false    221            �            1259    16390    User_Id_seq    SEQUENCE     v   CREATE SEQUENCE public."User_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public."User_Id_seq";
       public               postgres    false    218                       0    0    User_Id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."User_Id_seq" OWNED BY public."User"."Id";
          public               postgres    false    217            c           2604    16405    Subscriptions Id    DEFAULT     z   ALTER TABLE ONLY public."Subscriptions" ALTER COLUMN "Id" SET DEFAULT nextval('public."Subscriptions_Id_seq"'::regclass);
 C   ALTER TABLE public."Subscriptions" ALTER COLUMN "Id" DROP DEFAULT;
       public               postgres    false    220    219    220            b           2604    16394    User Id    DEFAULT     h   ALTER TABLE ONLY public."User" ALTER COLUMN "Id" SET DEFAULT nextval('public."User_Id_seq"'::regclass);
 :   ALTER TABLE public."User" ALTER COLUMN "Id" DROP DEFAULT;
       public               postgres    false    217    218    218            d           2604    16412    UserSubscriptions Id    DEFAULT     �   ALTER TABLE ONLY public."UserSubscriptions" ALTER COLUMN "Id" SET DEFAULT nextval('public."UserSubscriptions_Id_seq"'::regclass);
 G   ALTER TABLE public."UserSubscriptions" ALTER COLUMN "Id" DROP DEFAULT;
       public               postgres    false    222    221    222                      0    16402    Subscriptions 
   TABLE DATA           7   COPY public."Subscriptions" ("Id", "Name") FROM stdin;
    public               postgres    false    220   �"       �          0    16391    User 
   TABLE DATA           B   COPY public."User" ("Id", "UserName", "UserPassword") FROM stdin;
    public               postgres    false    218   �"                 0    16409    UserSubscriptions 
   TABLE DATA           \   COPY public."UserSubscriptions" ("Id", "UserId", "SubscriptionId", "StartDate") FROM stdin;
    public               postgres    false    222   l#                  0    0    Subscriptions_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Subscriptions_Id_seq"', 4, true);
          public               postgres    false    219                       0    0    UserSubscriptions_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."UserSubscriptions_Id_seq"', 8, true);
          public               postgres    false    221                       0    0    User_Id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public."User_Id_seq"', 8, true);
          public               postgres    false    217            h           2606    16407     Subscriptions Subscriptions_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."Subscriptions"
    ADD CONSTRAINT "Subscriptions_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."Subscriptions" DROP CONSTRAINT "Subscriptions_pkey";
       public                 postgres    false    220            j           2606    16414 (   UserSubscriptions UserSubscriptions_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public."UserSubscriptions"
    ADD CONSTRAINT "UserSubscriptions_pkey" PRIMARY KEY ("Id");
 V   ALTER TABLE ONLY public."UserSubscriptions" DROP CONSTRAINT "UserSubscriptions_pkey";
       public                 postgres    false    222            f           2606    16396    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public                 postgres    false    218            k           2606    16420 4   UserSubscriptions FK_UserSubscriptions_Subscriptions    FK CONSTRAINT     �   ALTER TABLE ONLY public."UserSubscriptions"
    ADD CONSTRAINT "FK_UserSubscriptions_Subscriptions" FOREIGN KEY ("SubscriptionId") REFERENCES public."Subscriptions"("Id");
 b   ALTER TABLE ONLY public."UserSubscriptions" DROP CONSTRAINT "FK_UserSubscriptions_Subscriptions";
       public               postgres    false    222    220    4712            l           2606    16415 ,   UserSubscriptions FK_UserSubscriptions_Users    FK CONSTRAINT     �   ALTER TABLE ONLY public."UserSubscriptions"
    ADD CONSTRAINT "FK_UserSubscriptions_Users" FOREIGN KEY ("UserId") REFERENCES public."User"("Id");
 Z   ALTER TABLE ONLY public."UserSubscriptions" DROP CONSTRAINT "FK_UserSubscriptions_Users";
       public               postgres    false    218    4710    222               <   x�3�tI�̩T�-�2����+ɠ�E\Ɯ���E%�E4��˄���(3/��v������� ��;�      �   �   x����1D�sR�];�ǽpq!!@��&��#�������e�Ҕ	� ������XG�<�C����8H�(�bM�({�(�|l�)�+E�'�)CT:7?�Z��0�<C��$��f�%����k��k�p4         /   x�3�4�4�4202�54�54�2
!���́&�1z\\\ �=h     